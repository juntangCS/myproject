'use strict';

var gulp = require('gulp');
var browserify = require('browserify');
var uglify = require('gulp-uglify');
var source = require('vinyl-source-stream');
var buffer = require('vinyl-buffer');
var gutil = require('gulp-util');

//gulp.task('default', function() {
//    gutil.log('message');
//    gutil.log(gutil.colors.red('error'));
//    gutil.log(gutil.colors.green('message:') + "some");
//});

//gulp.task('minify', function () {
//    gulp.src('js/app.js')
//        .pipe(uglify())
//        .pipe(gulp.dest('build'));
//});

gulp.task('browserify', function () {
    return browserify('./src/js/app.js')
      .bundle()
      .pipe(source('bundle.js')) // gives streaming vinyl file object
      .pipe(buffer()) // <----- convert from streaming to buffered vinyl file object
      .pipe(uglify()) // now gulp-uglify works 
      .pipe(gulp.dest('./dist/js'));
});


//gulp.task('watch', function() {
//    gulp.watch('controllers/*.js', ('build'));
//});
