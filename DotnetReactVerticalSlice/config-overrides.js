/* config-overrides.js */

const path = require("path");
const ModuleScopePlugin = require('react-dev-utils/ModuleScopePlugin');

module.exports = {
    paths: function (paths, env) {
        paths.appIndexJs = path.resolve(__dirname, 'src/Frontend/index.tsx');
        //paths.appSrc = path.resolve(__dirname, 'src/Frontend');
        return paths;
    },  
    //webpack: function(config, env) {
    //    config.resolve.plugins = config.resolve.plugins.filter(plugin => !(plugin instanceof ModuleScopePlugin));

    //    return config;
    //}
}