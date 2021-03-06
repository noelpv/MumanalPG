$(function() {
    
    //Modal
    var modal_type = 'modal';
    $('a[data-modal="link"]').click(function (e) {
        e.preventDefault();

        var url_load = $(this).attr('href');
        var title = $(this).data('original-title') || $(this).attr('title');
        var dataRedirect = $(this).data('redirect');
        var onlyRead = $(this).data('modal-read') === 'True';
        var modalDelete = $(this).data('modal-delete') === 'True';
        var modalPrint = $(this).data('modal-print') === 'True';
        var urlPrint = $(this).data('modal-url-print');
        var btnSave =  $('#'+ modal_type + '-save');
        var btnPrint =  $('#'+ modal_type + '-print');
        var size = $(this).data('modal-size');
        $('#' + modal_type).find('.modal-dialog').first().removeClass('modal-xl');
        if(size){
            $('#' + modal_type).find('.modal-dialog').first().addClass(size); 
        }
        
        if(onlyRead){
           btnSave.hide();
        }else {
            btnSave.show(); 
        }
        
        if (modalPrint && urlPrint) {
            btnPrint.show();
            btnPrint.attr('href', urlPrint);
        } else {
            btnPrint.hide();
        }
        
        if(modalDelete) {
            btnSave.removeClass('btn-success').addClass('btn-danger');
            btnSave.html('<i class="fas fa-times animated rollIn mr-2"></i> Eliminar');
        } else {
            btnSave.removeClass('btn-danger').addClass('btn-success');
            btnSave.html('<i class="fas fa-check animated rollIn mr-2"></i> Guardar');            
        }
        
        $('#' + modal_type).modal({
            backdrop: 'static',
            keyboard: false
        });
        $(".preloader-modal").fadeIn();
        $('#'+ modal_type + '-title').html(title);
        $.get(url_load).done(function (data) {
            $(".preloader-modal").fadeOut();
            $('#modal-body').html(data);
            if(!onlyRead){
                $('#'+ modal_type + '-save').unbind().click(function () {
                    $(".preloader-modal").show();
                    var form = $(this).parents('.modal').find('form');
                    var actionUrl = form.attr('action');
                    var dataToSend = form.serialize();

                    $.post(actionUrl, dataToSend).done(function (data) {
                        $(".preloader-modal").fadeOut();
                        var modalBody =  $('#'+ modal_type + '-body');
                        modalBody.html(data);
                        InitializeEvents();
                        var isValid =  modalBody.find('[name="IsValid"]').val() === 'True';
                        if (isValid) {                            
                            $('#' + modal_type).modal('hide');
                            $(location).attr('href', dataRedirect);
                        }
                    });
                });  
            }
            
            InitializeEvents();
        });
    });    
    InitializeEvents();
});

function InitializeEvents() {
    //Inicializando Bootstrap-Switch 
    $("input.bootstrap-switch").bootstrapSwitch();
    
    $('a.show-loader').click(function(){
        $(".preloader").fadeIn();        
    });
    
    $('select.selectize-plugin').selectize({
        create: false,
        sortField: 'text'
    });
    
}

function startTour() {
    var tour = introJs();
    tour.setOption('tooltipPosition', 'auto');
    tour.setOption('positionPrecedence', ['left', 'right', 'top', 'bottom']);
    tour.start();
}

function buildOptionsSelectize(url, valueField, labelField, searchFields, renderTemplate, onChange, onIni) {
    return {
        valueField: valueField,
        labelField: labelField,
        searchField: searchFields,
        create: false,
        render: {
            option: renderTemplate
        },
        score: function(search) {
            var score = this.getScoreFunction(search);
            return function(item) {
                return score(item);
            };
        },
        load: function(query, callback) {
            //$('.selectize-control.remote').addClass('loading');
            if (!query.length) return callback();
            $.ajax({
                url: url + '?filter=' + encodeURIComponent(query),
                type: 'GET',
                error: function() {
                    callback();
                },
                success: function(res) {
                    try {
                        callback(res.repositories.slice(0, 10));
                    } catch (e) {

                    }

                }
            });
        },
        onInitialize: onIni,
        onChange: onChange
    }
}