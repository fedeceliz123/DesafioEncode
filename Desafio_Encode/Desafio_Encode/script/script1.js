function verClave() {
    
         
    

        console.log("click");

    if (document.getElementById('tbContrasena').type == "password") {

        document.getElementById('tbContrasena').type = "text";
        }
    else{
        document.getElementById('tbContrasena').type = "password";
        }
       
    }

document.getElementById("ver").onclick = function () {
    verClave()
}