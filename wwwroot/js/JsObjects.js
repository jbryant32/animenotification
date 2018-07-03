
class movieObj {
    constructor(title, id, offeringSubbed, offeringDubbed, movieDates, theatricalReleaseStartDate, youTube
        , poster_path, backdrop_path, overview, theaterUrl) {
        this.title = title;
        this.id = id;
        this.offeringSubbed = offeringSubbed;
        this.offeringDubbed = offeringDubbed;
        this.movieDates = movieDates;
        this.theatricalReleaseStartDate = theatricalReleaseStartDate;
        this.youTube = youTube;
        this.poster_path = poster_path;
        this.backdrop_path = backdrop_path;
        this.overview = overview;
        this.theaterUrl = theaterUrl;
    }
    getMovieObject() {
        return {

            "title": this.movieTitle,
            "id": this.id,
            "offeringSubbed": this.isEnglishSubbed,
            "offeringDubbed": this.isEnglishDubbed,
            "movieDates": this.savedMovieDates,
            "theatricalReleaseStartDate": this.showingStartDate,
            "youTube": this.youTubeID,
            "poster_path": this.posterPath,
            "backdrop_path": this.backdropPath,
            "overview": this.overview,
            "theaterUrl": this.theaterUrl
        }
    }
    getMovieRawJsonObject() {
        var jsonObj = {

            "title": this.movieTitle,
            "id": this.id,
            "offeringSubbed": this.isEnglishSubbed,
            "offeringDubbed": this.isEnglishDubbed,
            "movieDates": this.savedMovieDates,
            "theatricalReleaseStartDate": this.showingStartDate,
            "youTube": this.youTubeID,
            "poster_path": this.posterPath,
            "backdrop_path": this.backdropPath,
            "overview": this.overview,
            "theaterUrl": this.theaterUrl
        }
        return JSON.stringify(jsonObj);
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
        id.innerText = movieDataforDb["id"]
        offeringSubbed.innerText = movieDataforDb["offeringSubbed"]
        offeringDubbed.innerText = movieDataforDb["offeringDubbed"]
        movieDates.innerText = movieDataforDb["movieDates"]
        theatricalReleaseStartDate.innerText = movieDataforDb["theatricalReleaseStartDate"]
        youTube.innerText = movieDataforDb["youTube"]
        poster_path.innerText = movieDataforDb["poster_path"]
        backdrop_path.innerText = movieDataforDb["backdrop_path"]
        overview.innerText = movieDataforDb["overview"]
        theaterUrl.innerText = movieDataforDb["theaterUrl"]

        //set attributes
        mainContainer.setAttribute("id", "saved-movie-item");
        mainContainer.setAttribute("class", "container-border saved-movie-item ");
        mainContainer.setAttribute("data-movieId", movieDataforDb["id"]);
        closeIcon.setAttribute("class", '"far fa-window-close fa-4x"');
        closeIcon.addEventListener("click", (e) => {
            var movieId = $(e.target.parentElement).attr("data-movieId");
            console.log(movieId);

            var toRemove = Array.from(document.getElementById("saved-movie-item-container").getElementsByClassName("saved-movie-item"));
            toRemove.forEach((item) => {
                var title = item.getAttribute("data-movieId");
                if (title === movieId) {
                    console.log(title);
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