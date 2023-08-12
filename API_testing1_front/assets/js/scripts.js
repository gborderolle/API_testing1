//on ready
document.addEventListener("DOMContentLoaded", init);

const URL_API = "https://localhost:5001/api";


function init(){
    search();
}

async function search(){
    var url_final = URL_API + "/customer";
    console.log(url_final);
    var response = await fetch(url_final, {
        "method":'GET',
        "headers":{
            "Content-Type":'application/json'
        }
    });

    //debugger;
    var result = await response.json();

    var html = '';
    for(customer of result){
        debugger;
        var row =`<tr>
        <td>${customer.name}</td>
        <td>${customer.email}</td>
        <td>${customer.phone}</td>
        <td>${customer.address}</td>
        <td><button class="btn btn-sm btn-warning">Editar</button>
            <button class="btn btn-sm btn-danger">Borrar</button></td>
        </tr>`    
        html+=row;
    }
    
  $("#tableCustomers").append(html);
}

