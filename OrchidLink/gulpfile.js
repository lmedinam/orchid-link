import gulp from 'gulp'
import dartSass from 'sass';
import gulpSass from 'gulp-sass';
import { deleteAsync } from 'del';

const sass = gulpSass(dartSass);

gulp.task('styles', () => {
    return gulp.src('resources/sass/**/*.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest('wwwroot/css/'));
});

gulp.task('watch', () => {
    gulp.watch('resources/sass/**/*.scss', (done) => {
        gulp.series(['clean', 'styles'])(done);
    });
});

gulp.task('clean', () => {
    return deleteAsync([
        'wwwroot/css/main.css',
    ]);
});

gulp.task('default', gulp.series(['clean', 'styles']));
