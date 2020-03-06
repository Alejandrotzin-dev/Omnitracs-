
/**
 * local weather function
 * @param {any} $section html element
 */
var localWeather = function ($section) {
    var _this = this;

    /**url to get local weather */
    _this.url = "Home/LocalWeather";

    /**
     * Load weather
     * @param {any} latitude latitude value
     * @param {any} longitude longitude value
     */
    _this.loadLocalWeather = function (latitude, longitude) {
        var data = JSON.stringify({
            "latitude": latitude,
            "longitude": longitude
        });

        $.ajax({
            url: _this.url,
            type: "POST",
            data: data,
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                $section.html(response);
            },
            error: function (xhr, message) {
                console.log(message);
                console.log(xhr);
            }
        });
    };

    /**Validate if geolocation is avilable */
    _this.validateGeolocation = function () {
        if (!navigator.geolocation) {
            alert('Geolocation is not supported by your browser');
        } else {
            navigator.geolocation.getCurrentPosition(success, error);
        }

        /**if there is an error, display message */
        function error() {
            alert('Unable to retrieve your location. Please allow it');
        }

        /**
         * if location is avilable, request weather
         * @param {any} position position data
         */
        function success(position) {
            let latitude = position.coords.latitude;
            let longitude = position.coords.longitude;
            _this.loadLocalWeather(latitude, longitude);
        }
    };

    /**initializer of object */
    _this.initializer = function () {
        _this.validateGeolocation();
    };
};

(function () {
    console.log("iniciando");
    const $section = $("#weather");
    var weather = new localWeather($section);
    console.log(weather);
    weather.initializer();
})();

