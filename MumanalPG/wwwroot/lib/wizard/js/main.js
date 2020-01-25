$(document).ready(function() {
    var form = $(".wizard-form");
    form.validate({
        errorPlacement: function errorPlacement(error, element) {
            element.before(error);
        },
        rules: {
            email: {
                email: true
            }
        },
        onfocusout: function(element) {
            $(element).valid();
        },
    });
    form.children("div").steps({
        headerTag: "h3",
        bodyTag: "fieldset",
        transitionEffect: "fade",
        stepsOrientation: "vertical",
        titleTemplate: '<div class="title"><span class="step-number">#index#</span><span class="step-text">#title#</span></div>',
        labels: {
            previous: 'Anterior',
            next: 'Siguiente',
            finish: 'Finalizar',
            current: ''
        },
        onStepChanging: function(event, currentIndex, newIndex) {
            // if (currentIndex === 0) {
            //     form.parent().parent().parent().append('<div class="footer footer-' + currentIndex + '"></div>');
            // }
            // if (currentIndex > 1) {
            //     $('a[role="menuitem"]').addClass('disabled');
            // }
            // if (currentIndex === 2) {
            //     form.parent().parent().parent().find('.footer').removeClass('footer-1').addClass('footer-' + currentIndex + '');
            // }
            // if (currentIndex === 3) {
            //     form.parent().parent().parent().find('.footer').removeClass('footer-2').addClass('footer-' + currentIndex + '');
            // }
            // if(currentIndex === 4) {
            //     form.parent().parent().parent().append('<div class="footer" style="height:752px;"></div>');
            // }
            form.validate().settings.ignore = ":disabled";
            return form.valid();
        },
        onFinishing: function(event, currentIndex) {
            form.validate().settings.ignore = ":disabled";
            return form.valid();
        },
        onFinished: function(event, currentIndex) {
            $(".preloader").fadeIn();
            form.submit();
        },
        onStepChanged: function(event, currentIndex, priorIndex) {
            if(currentIndex === 1) {
                var is_valid = false;

                $('[id*="ins_fun_"]').each(function() {
                    if($(this).val()){
                        var ins_value = JSON.parse($(this).val());
                        if(ins_value.instrucciones.length === 0) {
                            is_valid = false;
                            return false;
                        } else {
                            is_valid = true;
                        }
                    }
                });
                if(is_valid) {
                    $('a[role="menuitem"]').removeClass('disabled');
                } else {
                    $('a[role="menuitem"]').addClass('disabled');
                }
            } else {
                $('a[role="menuitem"]').removeClass('disabled');
            }
            return true;
        }
    });

    jQuery.extend(jQuery.validator.messages, {
        required: "",
        remote: "",
        email: "",
        url: "",
        date: "",
        dateISO: "",
        number: "",
        digits: "",
        creditcard: "",
        equalTo: ""
    });

    $.dobPicker({
        daySelector: '#birth_date',
        monthSelector: '#birth_month',
        yearSelector: '#birth_year',
        dayDefault: '',
        monthDefault: '',
        yearDefault: '',
        minimumAge: 0,
        maximumAge: 120
    });
    var marginSlider = document.getElementById('slider-margin');
    if (marginSlider != undefined) {
        noUiSlider.create(marginSlider, {
              start: [1100],
              step: 100,
              connect: [true, false],
              tooltips: [true],
              range: {
                  'min': 100,
                  'max': 2000
              },
              pips: {
                    mode: 'values',
                    values: [100, 2000],
                    density: 4
                    },
                format: wNumb({
                    decimals: 0,
                    thousand: '',
                    prefix: '$ ',
                })
        });
        var marginMin = document.getElementById('value-lower'),
	    marginMax = document.getElementById('value-upper');

        marginSlider.noUiSlider.on('update', function ( values, handle ) {
            if ( handle ) {
                marginMax.innerHTML = values[handle];
            } else {
                marginMin.innerHTML = values[handle];
            }
        });
    }
});