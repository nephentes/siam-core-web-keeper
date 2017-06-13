/// <reference path="bower_components/angular/angular.min.js" />
/// <reference path="bower_components/angular/angular.js" />
module.exports = function (grunt) {
    grunt.initConfig({
        clean: ["wwwroot/lib/*", "temp/"],
        concat: {
            all: {
                src: ['bower_components/jquery/dist/jquery.js',
                    'bower_components/angular/angular.js',
                    'bower_components/angular-route/angular-route.js',
                    'bower_components/bootstrap/dist/js/bootstrap.js',
                    'bower_components/angular-local-storage/dist/angular-local-storage.js'],
                dest: 'wwwroot/lib/dependencies.js'
            }
        },
        copy: {
            main: {
                expand: true,
                cwd: 'Frontend',
                src: '**',
                dest: 'wwwroot/',
            },
        },
    });

    grunt.loadNpmTasks("grunt-contrib-clean");
    grunt.loadNpmTasks('grunt-contrib-concat');
    grunt.loadNpmTasks('grunt-contrib-copy');
};