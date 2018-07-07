
class dataBaseEdit {
    constructor() {
        this.dbMovies = [{}];
        //saves the new user defined inputs
        document.querySelectorAll('input').forEach((element) => {
            element.addEventListener("focusout", () => {
                if (this.indexSelected !== NaN)
                {
                    this.saveStateInputValues()
                };
              
            });
        });

    }

    openConnectionToDb() {

        var completedTask = new Promise((success, fail) => {
            $.ajax({
                method: "GET",
                url: getAllMovieRestUrl,
                success: (payload) => {
                    success(payload);
                    this.dbMovies = payload;
                },
                error: (message) => {
                    fail(message)
                }
            })

        })

        return completedTask;
    }

    saveStateInputValues() {
       
        this.dbMovies[this.indexSelected]["title"] = $('input[data-id="title"]').val()
        this.dbMovies[this.indexSelected]["id"] = $('input[data-id="id"]').val();
        this.dbMovies[this.indexSelected]["offeringSubbed"] = $('input[data-id="offeringSubbed"]').val();
        this.dbMovies[this.indexSelected]["offeringDubbed"] = $('input[data-id="offeringDubbed"]').val();
        this.dbMovies[this.indexSelected]["movieDates"] = $('input[data-id="movieDates"]').val();
        this.dbMovies[this.indexSelected]["theatricalReleaseStartDate"] = $('input[data-id="releaseDate"]').val();
        this.dbMovies[this.indexSelected]["youTube"] = $('input[data-id="youTube"]').val();
        this.dbMovies[this.indexSelected]["poster_lg"] = $('input[data-id="posterPath"]').val();
        this.dbMovies[this.indexSelected]["backdrop_lg"] = $('input[data-id="backdropPath"]').val();
        this.dbMovies[this.indexSelected]["theaterUrl"] = $('input[data-id="theaterUrl"]').val();
        
    }

    //called on every click of table item
    populateInputs(selectedId) {
     
        this.dbMovies.forEach((item, index) => {

            if (selectedId == item.id) {
            
                this.indexSelected = index;
                //$('#title').val(item.title);
                document.getElementById("title").value = item.title;
                $('input[data-id="id"]').val(item.id);
                $('input[data-id="offeringSubbed"]').val(item.subbed);
                $('input[data-id="offeringDubbed"]').val(item.dubbed);
                $('input[data-id="movieDates"]').val(item.showings);
                $('input[data-id="releaseDate"]').val(item.releaseDate);
                $('input[data-id="youTube"]').val(item.trailer);
                $('input[data-id="posterPath"]').val(item.poster_lg);
                $('input[data-id="backdropPath"]').val(item.backdrop_lg);
                $('input[data-id="theaterUrl"]').val(item.theaterUrl);
                $('input[data-id="movieDates"]').val(item.showings.toString());
                document
                    .getElementById("movie-media-overview")
                    .getElementsByTagName("p")[0]
                    .innerText = item.overview;
               
            }
          
        })
    }
    //create and fill table with data from ajax call add eventlistener
    fillTable(dbData) {

        dbData.forEach((item,index) => {
            var tr = document.createElement("tr");
            var td = document.createElement("td");
            var tdTwo = document.createElement("td");
            tdTwo.innerText = item.id;
            td.innerText = item.title
            tr.appendChild(tdTwo);
            tr.appendChild(td);
            tr.addEventListener("click", (e) => {
                var id = e.path[1].getElementsByTagName("td")[0].innerText;
                this.populateInputs(id)
            });
            document
                .getElementById("movie-table")
                .appendChild(tr);
        })
   
    }
}
