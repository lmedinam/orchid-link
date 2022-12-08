import gulp from 'gulp'
import dartSass from 'sass';
import gulpSass from 'gulp-sass';
import source from 'vinyl-source-stream';
import buffer from 'vinyl-buffer';
import browserify from 'browserify';
import log from 'gulplog';
import uglify from 'gulp-uglify';
import { deleteAsync } from 'del';

const sass = gulpSass(dartSass);

gulp.task('styles', () => {
    return gulp.src('resources/sass/**/*.scss')
        .pipe(sass({
           includePaths: [
               'node_modules/foundation-sites/scss' 
           ]
        })
        .on('error', sass.logError))
        .pipe(gulp.dest('wwwroot/css/'));
});
gulp.task('js', () => {
    let bundleStream = browserify('./resources/js/site.js').bundle();

    return bundleStream
        .pipe(source('site.js'))
        .pipe(buffer())
            .pipe(uglify())
            .on('error', log.error)
        .pipe(gulp.dest('./wwwroot/js/'));
});

gulp.task('watch', () => {
    gulp.watch('resources/**/*.scss', (done) => {
        gulp.series(['clean', 'styles', 'js'])(done);
    });
});

gulp.task('clean', () => {
    return deleteAsync([
        'wwwroot/css/site.css',
    ]);
});

gulp.task('default', gulp.series(['clean', 'styles', 'js']));
