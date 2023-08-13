document.addEventListener("DOMContentLoaded", init);

const URL_API = "https://localhost:5001/api";
let listCustomers = [];

function init() {
  getCustomers();
}

async function apiRequest(url, method = "GET", data = null) {
  try {
    const options = {
      method: method,
      headers: {
        "Content-Type": "application/json",
      },
    };

    if (data) {
      options.body = JSON.stringify(data);
    }

    const response = await fetch(url, options);

    if (!response.ok) {
      throw new Error(`Error! status: ${response.status}`);
    }

    return await response.json();
  } catch (err) {
    console.log(err);
  }
}

async function getCustomers() {
  const urlFinal = `${URL_API}/customer`;
  listCustomers = await apiRequest(urlFinal);

  let html = "";

  listCustomers.forEach((customer, index) => {
    html += `
            <tr>
                <td>${index + 1}</td>
                <td>${customer.name}</td>
                <td>${customer.email}</td>
                <td>${customer.phone}</td>
                <td>${customer.address}</td>
                <td>
                    <button class="btn btn-sm btn-warning" data-bs-toggle="modal" data-bs-target="#myModal" onClick="editCustomer(${
                      customer.id
                    })">Editar</button>
                    <button class="btn btn-sm btn-danger" onClick="deleteCustomer(${
                      customer.id
                    })">Borrar</button>
                </td>
            </tr>
        `;
  });

  $("#tableCustomers > tbody").append(html);
}

async function deleteCustomer(id) {
  if (confirm("¿Está seguro que desea borrar?")) {
    const urlFinal = `${URL_API}/customer/${id}`;
    await apiRequest(urlFinal, "DELETE");
    // Instead of reloading, maybe consider updating the DOM or notifying the user.
    window.location.reload();
  }
}

async function saveCustomer() {
  const data = {
    name: document.getElementById("txbName").value,
    email: document.getElementById("txbEmail").value,
    phone: document.getElementById("txbPhone").value,
    address: document.getElementById("txbAddress").value,
  };

  var type = "POST";
  var id = document.getElementById("txbId").value;
  // Es edición
  if (id != "") {
    data.id = id;
    type = "PUT";
  }

  const urlFinal = `${URL_API}/customer`;
  await apiRequest(urlFinal, type, data);
  window.location.reload();
}

function editCustomer(id) {
  const customer = listCustomers.find((x) => x.id == id);
  if (customer) {
    document.getElementById("txbId").value = id;
    document.getElementById("txbName").value = customer.name;
    document.getElementById("txbEmail").value = customer.email;
    document.getElementById("txbPhone").value = customer.phone;
    document.getElementById("txbAddress").value = customer.address;
  }
}

function cleanModal() {
  document.getElementById("txbId").value = "";
  document.getElementById("txbName").value = "";
  document.getElementById("txbEmail").value = "";
  document.getElementById("txbPhone").value = "";
  document.getElementById("txbAddress").value = "";
}
