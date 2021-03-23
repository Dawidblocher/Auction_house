$(document).ready(function () {
    const form = document.querySelector("#bet-form");

    form.addEventListener("submit", event => {
        event.preventDefault();
 
        var auctionId = $('#bet-form').attr('idauction');
        var pricebet = $('#bet-form input#Price').val();

        $.ajax({
            url: event.target.baseURI,
            type: "POST",
            data: {
                id: auctionId,
                price: pricebet
            },
          
        })
            .done(function (response) {
                if (response) {
                    $('.massage-wrap').html(`
                                            <div class="alert alert-success" role="alert">
                                              Podbiłeś cenę!
                                            </div>
                                            `);

                    $('.auction-price h4').text('Wygrywasz aukcję!');
                    $('.auction-price span.price').text('Aktualna cena: ' + pricebet + ' zł');
                } else {
                    $('.massage-wrap').html(`
                                            <div class="alert alert-danger" role="alert">
                                              Podaj prawidłową cenę!
                                            </div>
                                            `);
                }
        })
        .fail(function () {
                console.log('Błąd');
        })
        
    });
});


