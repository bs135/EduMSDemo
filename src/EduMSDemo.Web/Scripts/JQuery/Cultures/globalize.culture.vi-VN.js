(function( window, undefined ) {

var Globalize;

if ( typeof require !== "undefined" &&
    typeof exports !== "undefined" &&
    typeof module !== "undefined" ) {
    // Assume CommonJS
    Globalize = require( "globalize" );
} else {
    // Global variable
    Globalize = window.Globalize;
}

Globalize.addCultureInfo( "vi-VN", "default", {
    name: "vi-VN",
    englishName: "Vietnamese",
    nativeName: "Tiếng Việt",
    numberFormat: {
        currency: {
            pattern: ["-$n","$n"],
            symbol: "₫"
        }
    },
    calendars: {
        standard: {
            firstDay: 1,
            patterns: {
                d: "dd/MM/yyyy",
                dt: "dd/MM/yyyy HH:mm",
                D: "dd MMMM yyyy",
                t: "HH:mm",
                T: "HH:mm:ss",
                f: "dd MMMM yyyy HH:mm",
                F: "dd MMMM yyyy HH:mm:ss",
                M: "dd MMMM",
                Y: "MMMM yyyy"
            }
        }
    }
});

}( this ));

Globalize.culture("vi-VN");