
class databaseEntry {
    constructor(showDates) {
        this.showDates = [];
        this.idInputHasValues = false;
        document.getElementById("clearButton").addEventListener("click", (e) => { this.clearMovieDates() })
        document.getElementById("submitMoviesButton").addEventListener("click", (e) => {
            $.ajax({
                method: "POST",
                url: baseUrl + postMoviesUrl,
                data: JSON.stringify( this.createObjectsForServer()),
                dataType: 'json',
                contentType:'application/json',
                success: (msg) => { console.log(msg) },
                error: (msg) => { console.log(msg) }
            })
        });
        $(document).ready(() => {

            $("#pickShowingDates #datepicker").datepicker({
                onSelect: this.addSeletedMovieShowDates

            });
        })

    }


    commitMoviesToAjax() {

    }
    //creates movies object and adds to array for being sent to server
    createObjectsForServer() {
        var elemObjects = Array.from(document.querySelectorAll("#saved-movie-item"));
        elemObjects.forEach((elem) => {

            var title = $(elem).find('#title').text();
            var id = $(elem).find('#id').text();
            var offeringSubbed = $(elem).find('#offeringSubbed').text();
            var offeringDubbed = $(elem).find('#offeringDubbed').text();
            var releaseDate = $(elem).find('#releaseDate').text();
            var youTube = $(elem).find('#youTube').text();
            var poster_path = $(elem).find('#poster_path').text();
            var backdrop_path = $(elem).find('#backdrop_path').text();
            var theaterUrl = $(elem).find('#theaterUrl').text();
            var overview = $(elem).find('#overview').text();
            var MovieData = {
                "title": title,
                "id": id,
                "offeringSubbed": offeringSubbed,
                "offeringDubbed": offeringDubbed,
                "movieDates": (function () {
                  
                    var tmp = [];
                    dbEntry.showDates.forEach((movieDate) => {
                        if (movieDate.id === id)
                            tmp.push(movieDate.date)
                    });
                    return tmp;
                })(),
                "theatricalReleaseStartDate": releaseDate,
                "youTube": youTube,
                "poster_path": poster_path,
                "backdrop_path": backdrop_path,
                "special_posterUrl": "",
                "overview": overview,
                "theaterUrl": theaterUrl
            };
            moviesForAjax.push(MovieData);
            
           
        })
        console.log(moviesForAjax);
        return moviesForAjax;
    }
    removeMovieFromAjax() { }

    //adds show date to the selected movie showings list and adds to the showDates array the movie id and the date
    addSeletedMovieShowDates(dateText, Inst) {

        var date = $(this).val();
        var id = document.getElementById("movieId").value;
       
        var movieShowings = { "id": id, "date": date };
        dbEntry.showDates.push(movieShowings);

        var li = document.createElement("li");
        li.setAttribute("id", "movieDate");
        li.innerText = date
        document.getElementById("movieShowDates").appendChild(li);
        
    }
    //when the clear button is pressed this removes the movie to be cleared from the showDates object array
    clearMovieDates() {
        var id = document.getElementById("movieId").value;
        document.getElementById("movieShowDates").innerHTML = "";
        var arrayLength = this.showDates.length;
        this.showDates.forEach((item,index) => {
            if (item.id === id) {
                var indx = this.showDates.indexOf(item)
                this.showDates.splice(indx,1);
            }
        });
      
    }

    clearAllMovieDates() {
        document.getElementById("movieShowDates").innerHTML = "";
        this.showDates = [];
        console.log(this.showDates)
    }
}



class savedMovieItem {
    //creates a dom item for the save movies div
    setDomItem(movieDataforDb) {

        //create elements out of movies propertys
        var mainContainer = document.createElement("div")
        var title = document.createElement("div");
        var id = document.createElement("div");
        var offeringSubbed = document.createElement("div");
        var offeringDubbed = document.createElement("div");
        var movieDates = document.createElement("div");
        var theatricalReleaseStartDate = document.createElement("div");
        var youTube = document.createElement("div");
        var poster_path = document.createElement("div");
        var overview = document.createElement("div");
        var backdrop_path = document.createElement("div");
        var theaterUrl = document.createElement("div");
        var closeIcon = document.createElement("i");

        //create labels
        var labelTitle = document.createElement("label");
        var labelid = document.createElement("label");
        var labelofferingSubbed = document.createElement("label");
        var labelofferingDubbed = document.createElement("label");
        var labelmovieDates = document.createElement("label");
        var labelyouTube = document.createElement("label");
        var labelposter_path = document.createElement("label");
        var labeloverview = document.createElement("label");
        var labelbackdrop_path = document.createElement("label");
        var labeltheatricalReleaseStartDate = document.createElement("label");
        var labeltheaterUrl = document.createElement("label");

        //define labels content
        labelTitle.innerText = "Title";
        labelid.innerText = "Id";
        labelofferingSubbed.innerText = "English Subbed Available";
        labelofferingDubbed.innerText = "English Dubbed Available";
        labelmovieDates.innerText = "Movie Dates";
        labeltheatricalReleaseStartDate.innerText = "TheatricalReleaseStartDate";
        labelyouTube.innerText = "YouTube";
        labelposter_path.innerText = "Poster";
        labelbackdrop_path.innerText = "Backdrop";
        labeltheaterUrl.innerText = "Theater Url";
        labeloverview.innerText = "Overview";
        var domContainer = document.getElementById("saved-movie-item-container");

        //populate inner test of items
        title.innerText = movieDataforDb["title"];
        title.setAttribute("id", "title");
        id.innerText = movieDataforDb["id"];
        id.setAttribute("id", "id");
        offeringSubbed.innerText = movieDataforDb["offeringSubbed"]
        offeringSubbed.setAttribute("id", "offeringSubbed");
        offeringDubbed.innerText = movieDataforDb["offeringDubbed"]
        offeringDubbed.setAttribute("id", "offeringDubbed");
        movieDates.innerText = movieDataforDb["movieDates"];
        movieDates.setAttribute("id", "movieDates");
        theatricalReleaseStartDate.innerText = movieDataforDb["theatricalReleaseStartDate"];
        theatricalReleaseStartDate.setAttribute("id", "releaseDate");
        youTube.innerText = movieDataforDb["youTube"]
        youTube.setAttribute("id", "youTube");
        poster_path.innerText = movieDataforDb["poster_path"]
        poster_path.setAttribute("id", "poster_path");
        backdrop_path.innerText = movieDataforDb["backdrop_path"]
        backdrop_path.setAttribute("id", "backdrop_path");
        overview.innerText = movieDataforDb["overview"]
        overview.setAttribute("id", "overview");
        theaterUrl.innerText = movieDataforDb["theaterUrl"];
        theaterUrl.setAttribute("id", "theaterUrl");

        //set attributes
        mainContainer.setAttribute("id", "saved-movie-item");
        mainContainer.setAttribute("class", "container-border saved-movie-item ");
        mainContainer.setAttribute("data-movieId", movieDataforDb["id"]);
        closeIcon.setAttribute("class", '"far fa-window-close fa-4x"');

        closeIcon.addEventListener("click", (e) => {
            var movieId = $(e.target.parentElement).attr("data-movieId");
          

            var toRemove = Array.from(document.getElementById("saved-movie-item-container").getElementsByClassName("saved-movie-item"));
            toRemove.forEach((item) => {
                var title = item.getAttribute("data-movieId");
                if (title === movieId) {
                   
                    document.getElementById("saved-movie-item-container")
                        .removeChild(item);
                }

            })
        });

        mainContainer.appendChild(labelTitle);
        mainContainer.appendChild(title)
        mainContainer.appendChild(labelid);
        mainContainer.appendChild(id)
        mainContainer.appendChild(labelofferingSubbed);
        mainContainer.appendChild(offeringSubbed)
        mainContainer.appendChild(labelofferingDubbed);
        mainContainer.appendChild(offeringDubbed)
        mainContainer.appendChild(labelmovieDates);
        mainContainer.appendChild(movieDates)
        mainContainer.appendChild(labeltheatricalReleaseStartDate);
        mainContainer.appendChild(theatricalReleaseStartDate);
        mainContainer.appendChild(labelyouTube);
        mainContainer.appendChild(youTube)
        mainContainer.appendChild(labelposter_path);
        mainContainer.appendChild(poster_path)
        mainContainer.appendChild(labeloverview);
        mainContainer.appendChild(overview)
        mainContainer.appendChild(labelbackdrop_path);
        mainContainer.appendChild(backdrop_path);
        mainContainer.appendChild(labeltheaterUrl);
        mainContainer.appendChild(theaterUrl);
        mainContainer.appendChild(closeIcon);
        domContainer.appendChild(mainContainer);

        Array.from(domContainer.getElementsByTagName("label")).forEach((item) => {
            item.insertAdjacentHTML("afterEnd", "<br />")
        });
        return mainContainer;
    }

    removeSaveItem(targetId) {
        var saveItemsContainer = document.getElementById("saved-movie-item-container")
            .getElementById("saved-movie-item");
        saveItemsContainer.forEach((item) => {
            console.log(item);
        });
    }
}