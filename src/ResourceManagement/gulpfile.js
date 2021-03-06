var path = require('path');
var gulp = require('gulp');
var args = require('yargs').argv;
var colors = require('colors');
var spawn = require('child_process').spawn;
var fs = require('fs');

const mappings = require('./api-specs.json');
const defaultSpecRoot = "https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master";

async function defaultInfo() {

    console.log("Usage: gulp codegen " +
        "[--spec-root <swagger specs root>] " +
        "[--projects <project names>] " +
        "[--autorest <autorest info>] " +
        "[--autorest-csharp <autorest.csharp info>] " +
        "[--debug] " +
        "[--autorest-args <AutoRest arguments>]\n");

    console.log("--spec-root");
    console.log(`\tRoot location of Swagger API specs, default value is "${defaultSpecRoot}"`);

    console.log("--projects");
    console.log("\tComma separated projects to regenerate, default is all. List of available project names:");
    Object.keys(mappings).forEach(function(i) {
        console.log('\t' + i.magenta);
    });

    console.log("--autorest");
    console.log("\tThe version of AutoRest. E.g. 2.0.9, or the location of AutoRest repo, e.g. E:\\repo\\autorest");

    console.log("--autorest-csharp");
    console.log("\tThe NPM version number for the autorest.csharp generator, e.g. @2.1.28 or @preview, or a file path to a local autorest.csharp generator.");
    console.log("\tUsually you'll only need to provide this and not a --autorest argument in order to work on C# code generation.");
    console.log("\tSee https://github.com/Azure/autorest/blob/master/docs/developer/autorest-extension.md");

    console.log("--debug");
    console.log("\tFlag that allows you to attach a debugger to the autorest.csharp generator.");

    console.log("--autorest-args");
    console.log("\tPasses additional argument to AutoRest generator");
}

var specRoot = args['spec-root'] || defaultSpecRoot;
var projects = args['projects'];
var autoRestVersion = 'latest'; // default
if (args['autorest'] !== undefined) {
    autoRestVersion = args['autorest'];
}
var debug = args['debug'];
var autoRestArgs = args['autorest-args'] || '';
var autoRestExe;

async function generate(cb) {
    if (autoRestVersion.match(/[0-9]+\.[0-9]+\.[0-9]+.*/) ||
        autoRestVersion == 'latest' || autoRestVersion == 'preview') {
        autoRestExe = 'autorest ---version=' + autoRestVersion;
        handleInput(projects, cb);
    } else {
        autoRestExe = "node " + path.join(autoRestVersion, "src/autorest-core/dist/app.js");
        handleInput(projects, cb);
    }
}

function handleInput(projects, cb) {
    if (projects === undefined) {
        Object.keys(mappings).forEach(function (proj) {
            codegen(proj, cb);
        });
    } else {
        projects.split(",").forEach(function (proj) {
            proj = proj.replace(/\ /g, '');
            if (mappings[proj] === undefined) {
                console.error('Invalid project name "' + proj + '"!');
                process.exit(1);
            }
            codegen(proj, cb);
        });
    }
}

function codegen(project, cb) {
    const regenManager = args['regenerate-manager'] ? ' --regenerate-manager=true ' : '';
    var outputDir = path.resolve(mappings[project].dir);
    if (!args['preserve']) {
        deleteFolderRecursive(outputDir);
    }
    console.log('Generating "' + project + '" from spec file ' + specRoot + '/' + mappings[project].source);
    var generator = '--fluent';
    if (mappings[project].fluent !== null && mappings[project].fluent === false) {
        generator = '';
    }

    const autorestCSArg = args['autorest-csharp'] || "@latest";
    const generatorPath = autorestCSArg.startsWith("@")
        ? "@microsoft.azure/autorest.csharp" + autorestCSArg
        : path.resolve(autorestCSArg);

    const autorestUseArg = `--use=${generatorPath}`;

    cmd = autoRestExe + ' ' + specRoot + "/" + mappings[project].source +
        ' --csharp ' +
        ' --azure-arm ' +
        generator +
        ' --csharp.sync-methods=none ' +
        ` --csharp.namespace=${mappings[project].package} ` +
        ` --csharp.output-folder=${outputDir} ` +
        ` --csharp.license-header=MICROSOFT_MIT_NO_CODEGEN ` +
        ` --csharp.clear-output-folder=false ` +
        autorestUseArg +
        regenManager +
	' --use=@microsoft.azure/autorest.csharp@preview' +
        ' --package-version=1.3.0 ' +
        ' --runtime-version=3.3.10 ' +
        autoRestArgs;

    if (mappings[project].args !== undefined) {
        cmd = cmd + ' ' + mappings[project].args;
    }

    if (debug) {
        cmd += ' --csharp.debugger';
    }

    console.log('Command: ' + cmd);
    spawn(cmd, [], { shell: true, stdio: "inherit" });
};

function deleteFolderRecursive(path) {
    var header = "Code generated by Microsoft (R) AutoRest Code Generator";
    if(fs.existsSync(path)) {
        fs.readdirSync(path).forEach(function(file, index) {
            var curPath = path + "/" + file;
            if(fs.lstatSync(curPath).isDirectory()) { // recurse
                deleteFolderRecursive(curPath);
            } else { // delete file
                var content = fs.readFileSync(curPath).toString('utf8');
                if (content.indexOf(header) > -1) {
                    fs.unlinkSync(curPath);
                }
            }
        });
    }
};

exports.default = defaultInfo;
exports.codegen = generate;
