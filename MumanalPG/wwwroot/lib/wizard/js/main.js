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
            //     // form.parent().parent().parent().append('<div class="footer footer-' + currentIndex + '"></div>');
            //     alert('1');
            // }

            if (currentIndex === 1) {
                let id_fun, inst_fun, inst_value;
                let is_valid = false;
                let errors = [];
                $('.derive-selected').each(function() {
                    let me = $(this);
                    id_fun = me.attr('id');
                    inst_fun = $(`input#ins_${id_fun}`);
                    if(inst_fun.length && inst_fun.val()) {
                        inst_value = JSON.parse(inst_fun.val());
                        if(inst_value.instrucciones.length === 0) {
                            errors.push(id_fun);
                            me.addClass('derive-selected-error');
                        } else {
                            me.removeClass('derive-selected-error');
                        }
                    }
                });
                if(errors.length > 0) {
                    let msg_error = $('<div id="errors" class="text-danger text-center mb-3">Los usuarios en rojo necesitan instrucciones.</div>');
                    $('#errors').remove();
                    $('.actions').first().prepend(msg_error);
                } else if($('.derive-selected').length){
                    $('#errors').remove();
                    is_valid = true;
                } else {
                    let msg_error = $('<div id="errors" class="text-danger text-center mb-3">Debe seleccionar almenos a una persona para derivar.</div>');
                    $('#errors').remove();
                    $('.actions').first().prepend(msg_error);
                }
                return is_valid;
            }
            
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
            let row_value, container_row, container_input;
            let anexo_errors = [];
            $('[id*="row_anexo_"]').each(function() {
                if($(this).val()){
                    row_value = JSON.parse($(this).val());
                    container_row = $(this).parents('div').first();
                    if(!(row_value.descripcion != null && row_value.descripcion.length)){
                        container_input = container_row.find('[id*="descripcion_"]').first().parents('div.form-group').first();
                        container_input.addClass('has-danger');
                        anexo_errors.push(container_row.find('[id*="descripcion_"]').first().attr('id'));
                    } else {
                        container_input = container_row.find('[id*="descripcion_"]').first().parents('div.form-group').first();
                        container_input.removeClass('has-danger');
                    }
                    
                    if(!(row_value.path != null && row_value.path.length)){
                        container_input = container_row.find('[id*="dropzone_"]').first().parents('div.form-group');
                        container_input.addClass('has-danger');
                        anexo_errors.push(container_row.find('[id*="dropzone_"]').first().attr('id'));
                    }else {
                        container_input = container_row.find('[id*="dropzone_"]').first().parents('div.form-group').first();
                        container_input.removeClass('has-danger');
                    }
                }
            });

            if(anexo_errors.length > 0) {
                let msg_error = $('<div id="errors" class="text-danger text-center mb-3">Corrija los campos en rojo.</div>');
                if( !$('#errors').length) {
                    $('.actions').first().prepend(msg_error);
                }
            } else {
                $('#errors').remove();
            }
            return !anexo_errors.length > 0;
        },
        onFinished: function(event, currentIndex) {
            $(".preloader").fadeIn();
            form.submit();
        },
        onStepChanged: function(event, currentIndex, priorIndex) {
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