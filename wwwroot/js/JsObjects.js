
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

 