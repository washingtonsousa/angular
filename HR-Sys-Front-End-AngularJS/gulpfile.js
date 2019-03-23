var compass = require('gulp-compass');
var gulp = require('gulp');


gulp.task("deploy_files" , function(data) {

gulp.src("node_modules/jquery/dist/jquery.js").pipe(gulp.dest("src/assets/js/"));
gulp.src("node_modules/bootstrap/dist/css/bootstrap.css").pipe(gulp.dest("src/assets/css/"));
gulp.src("node_modules/bootstrap/dist/js/bootstrap.js").pipe(gulp.dest("src/assets/js/"));
gulp.src("node_modules/font-awesome/css/font-awesome.min.css").pipe(gulp.dest("src/assets/css/"));
gulp.src("node_modules/font-awesome/fonts/**").pipe(gulp.dest("src/assets/fonts/"));

});



gulp.task('compass', function() {
    gulp.src('./src/_dev/scss/styles.scss')
      .pipe(compass({
        config_file: './src/_dev/config.rb',
        css:  './src/_dev/dist/css',
        sass: './src/_dev/scss'
      }))
      .pipe(gulp.dest('./src/_dev/dist/css'));
  });





gulp.task('compile-deploy', ['compass'] , function() {

gulp.src('./src/_dev/dist/css/styles.css').pipe(gulp.dest('./src/assets/css'));

});

gulp.task('watch-compile', function() {

gulp.watch('./src/_dev/**/*.scss', ['compile-deploy']);

});