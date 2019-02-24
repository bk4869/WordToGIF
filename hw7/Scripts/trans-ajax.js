$(document).ready(function () {


    $('#text-input').bind('keypress', function ( event )
    {

        if (event.which == 32) {

            keywordSearch();
            event.preventDefault;

        }

        function keywordSearch() {

            var userInput = $('#text-input').val();
            var latestWord = showLatest(userInput);

            if (!isPrepositions(latestWord)) {
                $.ajax({
                    url: '/Translator/Sticker',
                    type: 'GET',
                    data: { 'userInput': latestWord },
                    success: showResult,
                    error: errorReturn
                });
            } else {
                var str = latestWord;
                $('#returnView').append(" " + str);
                //alert(str);
            }
        }

        function showLatest(inputStr) {
            var strArray = inputStr.split(" ");
            //alert(strArray[strArray.length-1]);

            return strArray[strArray.length - 1];
        }

        function isPrepositions(word) {

            var popularPrepos = ['a', 'an', 'the', 'some', 'for', 'is', 'are', 'it', 'she', 'of',
                'with', 'at', 'from', 'into', 'during', 'including', 'until',
                'against', 'among', 'to', 'on', 'by'];

            //alert(word);

            var i;
            for (i = 0; i < popularPrepos.length; i++) {
                if (word == popularPrepos[i]) {
                    return true;
                    break;
                } 
            }
            return false;

        }

        function showResult(giphy) {

            var result = "";
            var giphyURL = giphy.data.images.fixed_height_still.url;

            result += "<img src='" + giphyURL + "' width=150px, height=150px/>";

            $('#returnView').append(result);

        }

        function errorReturn() {
            $('#returnView').append("!Error!");
        }

        $('#clearBtn').click(function () {
            location.reload();
        });



    });

});