
var getPages = (function(){
    var about1 = document.getElementById("about1");
    var about2 = document.getElementById("about2");
    var about3 = document.getElementById("about3");

    return{
        page1: function(){
            about1.style.display = "block";
            about2.style.display = "none";
            about3.style.display = "none";
        },
        page2: function(){
            about1.style.display = "none";
            about2.style.display = "block";
            about3.style.display = "none";
        },
        page3: function(){
            about1.style.display = "none";
            about2.style.display = "none";
            about3.style.display = "block";
        }
    }
})(getPages||{})