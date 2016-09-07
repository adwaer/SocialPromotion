var lr = require('tiny-lr'), // Минивебсервер для livereload
    gulp = require('gulp'), // Сообственно Gulp JS
    jade = require('gulp-jade'), // Плагин для Jade
    livereload = require('gulp-livereload'), // Livereload для Gulp
    myth = require('gulp-myth'), // Плагин для Myth - http://www.myth.io/
    csso = require('gulp-csso'), // Минификация CSS
    imagemin = require('gulp-imagemin'), // Минификация изображений
    uglify = require('gulp-uglify'), // Минификация JS
    ngAnnotate = require('gulp-ng-annotate'), // Аннатации angularjs правильной обфускации
    concat = require('gulp-concat'), // Склейка файлов
    connect = require('connect'), // Webserver
    server = lr(),
    serveStatic = require('serve-static');

// Собираем vendor css
gulp.task('css_vendor', function () {
    gulp.src([
            './node_modules/angular-bootstrap/ui-bootstrap-csp.css',
            './node_modules/bootstrap/dist/css/bootstrap.min.css'
        ])
        .pipe(concat('vendor.css'))
        .on('error', console.log) // Если есть ошибки, выводим и продолжаем
        .pipe(myth()) // добавляем префиксы - http://www.myth.io/
        .pipe(gulp.dest('./public/css/')) // записываем css
        .pipe(livereload(server)); // даем команду на перезагрузку css
});

// Собираем vendor JS
gulp.task('js_vendor', function () {
    gulp.src(['./node_modules/jquery/dist/jquery.min.js',
            './node_modules/angular/angular.min.js',
            './node_modules/angular-route/angular-route.min.js',
            './node_modules/angular-resource/angular-resource.min.js',
            './node_modules/angular-ui-bootstrap/dist/ui-bootstrap.js',
            './node_modules/angular-cookies/angular-cookies.js',
            './node_modules/ng-autocomplete/src/ngAutocomplete.js',
            './node_modules/ng-infinite-scroll/build/ng-infinite-scroll.js'])
        .pipe(concat('vendor.js'))
        .pipe(gulp.dest('./public/js'));
});

// Собираем html из Jade
gulp.task('jade', function () {
    gulp.src(['./assets/template/**/*.jade', '!./assets/template/_*.jade'])
        .pipe(jade({
            pretty: true
        }))  // Собираем Jade только в папке ./assets/template/ исключая файлы с _*
        .on('error', console.log) // Если есть ошибки, выводим и продолжаем
        .pipe(gulp.dest('./public/')); // Записываем собранные файлы
});

// Собираем css
gulp.task('css', function () {
    gulp.src('./assets/css/**/*.css')
        .on('error', console.log) // Если есть ошибки, выводим и продолжаем
        .pipe(myth()) // добавляем префиксы - http://www.myth.io/
        .pipe(gulp.dest('./public/css/')) // записываем css
        .pipe(livereload(server)); // даем команду на перезагрузку css
});

// Собираем JS
gulp.task('js', function () {
    gulp.src(['./assets/js/**/*.js', '!./assets/js/**/_*.js'])
        .pipe(concat('index.js')) // Собираем все JS, кроме тех которые находятся в ./assets/js/vendor/**
        .pipe(gulp.dest('./public/js'))
        .pipe(livereload(server)); // даем команду на перезагрузку страницы
});

// Собираем fonts
gulp.task('fonts', function () {
    gulp.src('./assets/fonts/**/*.*')
        .on('error', console.log) // Если есть ошибки, выводим и продолжаем
        .pipe(gulp.dest('./public/fonts/')) // записываем css
        .pipe(livereload(server)); // даем команду на перезагрузку css
});

// Копируем и минимизируем изображения
gulp.task('images', function () {
    gulp.src('./assets/img/**/*')
        .pipe(imagemin())
        .pipe(gulp.dest('./public/img'));
});

// Копируем настройки
gulp.task('settings', function () {
    gulp.src('./assets/settings.json')
        .pipe(gulp.dest('./public'));
});

// Локальный сервер для разработки
gulp.task('http-server', function () {
    var app = connect();
    app.use(serveStatic('./public'));
    app.listen('7778');

    console.log('Server listening on http://localhost:7778');
});

// Запуск сервера разработки gulp watch
gulp.task('watch', ['css_vendor', 'fonts', 'js_vendor', 'settings', 'http-server', 'css', 'jade', 'images', 'js'], function () {
    // Подключаем Livereload
    server.listen(35729, function (err) {
        if (err) return console.log(err);
        gulp.watch('./assets/css/**/*.css', ['css']);
        gulp.watch('./assets/template/**/*.jade', ['jade']);
        gulp.watch('./assets/img/**/*', ['images']);
        gulp.watch('./assets/js/**/*.js', ['js']);
    });
});

gulp.task('build', function () {
    // css vendor
    gulp.src([
            './node_modules/angular-bootstrap/ui-bootstrap-csp.css',
            './node_modules/bootstrap/dist/css/bootstrap.min.css'
        ])
        .pipe(concat('vendor.css'))
        .pipe(myth()) // добавляем префиксы - http://www.myth.io/
        .pipe(csso()) // минимизируем css
        .pipe(gulp.dest('./build/css/')); // записываем css

    // css
    gulp.src('./assets/css/**/*.css')
        .pipe(myth()) // добавляем префиксы - http://www.myth.io/
        .pipe(csso()) // минимизируем css
        .pipe(gulp.dest('./build/css/')); // записываем css


    // Собираем fonts
    gulp.task('fonts', function () {
        gulp.src('./assets/fonts/**/*.*')
            .on('error', console.log) // Если есть ошибки, выводим и продолжаем
            .pipe(gulp.dest('./build/fonts/')); // записываем css
    });

    // jade
    gulp.src(['./assets/template/**/*.jade', '!./assets/template/_*.jade'])
        .pipe(jade())
        .pipe(gulp.dest('./build/'));

    // js vendor
    gulp.src(['./node_modules/jquery/dist/jquery.min.js',
            './node_modules/angular/angular.min.js',
            './node_modules/angular-route/angular-route.min.js',
            './node_modules/angular-resource/angular-resource.min.js',
            './node_modules/angular-ui-bootstrap/dist/ui-bootstrap.js',
            './node_modules/angular-cookies/angular-cookies.js',
            './node_modules/ng-autocomplete/src/ngAutocomplete.js',
            './node_modules/ng-infinite-scroll/build/ng-infinite-scroll.js'
        ])
        .pipe(concat('vendor.js'))
        .pipe(ngAnnotate())
        .pipe(uglify())
        .pipe(gulp.dest('./build/js'));

    // js
    gulp.src(['./assets/js/**/*.js', '!./assets/js/**/_*.js'])
        .pipe(concat('index.js'))
        .pipe(ngAnnotate())
        .pipe(uglify())
        .pipe(gulp.dest('./build/js'));

    // image
    gulp.src('./assets/img/**/*')
        .pipe(imagemin())
        .pipe(gulp.dest('./build/img'))

    // settings
    gulp.src('./assets/settings.json')
        .pipe(gulp.dest('./build'));
});

gulp.task('default', ['watch'], function () {
});