(function () {
    $(document).ready(() => {

        $("#datepicker").attr('disabled', 'disabled')

        function checkInputIdValid() {
            var idInput = document.getElementById("movieId").value;

            if (idInput.length > 1) {
                return true
            }
            else { return false }
        }
        function checklistShowDatesValid() {
            var dates = document.getElementById("movieShowDates").getElementsByTagName("li");
            console.log(dates.length)
            if (dates.length > 0) {
                console.log("dates ready")
                return true;

            }
            else { return false; }
        }
        //checks if movies are in the movies container
        function checkMoviesConatiner() {
            var saveMoviesContainer = document.getElementById("saved-movie-item-container").childElementCount
            if (saveMoviesContainer > 0) {
                console.log("movies in basket")
                return true;
            }
            else {
                console.log("no movies");
                return false;
            }
        }
        function checkSubtmitReady() {
            var movieSaveCount = document.getElementById("saved-movie-item");
            if (movieSaveCount != null) {

                return true;
            }
            else {
                return false;
            } }
        function checkAddToQueReady() {
            var formInputs = Array.from($("input[type='text']"))
            var ready = false;
            formInputs.forEach((ele) => {
                var inputValue = $(ele).val();
                if (!inputValue) {

                    ready = false;

                }
                else {

                    ready = true;
                }
            })
            return ready;

        }
        function disableAll() {
            $("#datepicker").attr('disabled', 'disabled')
            $("#clearButton").attr('disabled', 'disabled')
            $("#checkMovieButton").attr('disabled', 'disabled')
            $("#addmoviebutton").attr('disabled', 'disabled')
            $("#submitMoviesButton").attr('disabled', 'disabled')
        }
        function enableAll() {
            $("#datepicker").prop('disabled', false)
            $("#clearButton").prop('disabled', false)
            $("#checkMovieButton").prop('disabled', false)
            $("#addmoviebutton").prop('disabled', false)
            $("#submitMoviesButton").prop('disabled', false)
        }
        function enableClear() {
            var ready = checklistShowDatesValid();
            if (ready) {
                $("#clearButton").prop('disabled', false);
            }
            else {
                $("#clearButton").attr('disabled', 'disabled')
            }
        }
        function enableCheckQue() {
            var moviesContainer = checkMoviesConatiner();
            if (moviesContainer) {
                $("#checkMovieButton").prop('disabled', false);

            }
            else {
                $("#checkMovieButton").prop('disabled', 'disabled');

            }
        }
        function enableSubmit() {
            var ready = checkSubtmitReady();
            if (ready) {
                $("#submitMoviesButton").prop('disabled', false);
            }
            else {
                $("#submitMoviesButton").attr('disabled', 'disabled')
            }

        }
        function enableAddToQue() {
            var ready = checkAddToQueReady();
            console.log(ready)
            if (ready) {
                $("#addmoviebutton").prop('disabled', false);
            }
            else {
                $("#addmoviebutton").attr('disabled', 'disabled')
            }
        }
        function enableShowDatesPicker() {
            var ready = checkInputIdValid()
            if (ready) {
                $("#datepicker").prop('disabled', false);
            }
            else {
                $("#datepicker").attr('disabled', 'disabled')
            }

        }

        document.getElementsByTagName("html")[0].addEventListener("click", () => {

            enableShowDatesPicker();
            enableClear();
            enableCheckQue();
            enableAddToQue();
            enableSubmit();

        })
    });




})();