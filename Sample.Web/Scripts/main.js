/// <reference path="lib/jquery-1.9.1.intellisense.js" />
(function () {
    //configure require.js
    require.config({
        shim: {
            'lib/jquery-1.9.1': {
                exports: '$'
            },
            'lib/backbone': {
                deps: ['lib/underscore', 'lib/jquery-1.9.1'],
                exports: 'Backbone'
            },
            'lib/underscore': {
                exports: '_'
            }
        }
    });

    //Application entry point logic
    //requirejs(['lib/jquery-1.9.1'], function ($) {
        //$(function () {
            //$('[data-require]').each(function(index, elem){
            //    var scriptName = $(elem).data("require");
            //    if (scriptName) {
            //        var found = require([scriptName]);
            //    }
            //});
        //});
    //});
}())