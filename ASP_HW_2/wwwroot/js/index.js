
if (location.pathname === "/index.html") {

    getBicycles();

    document.getElementById('add').addEventListener("click", function () {

        location.pathname = '/edit-page.html'
    })

    sessionStorage.clear();
}
else {
    let bicycle = JSON.parse(sessionStorage.getItem('bicycle'));

    if (bicycle != null ) {

        const form = document.forms['editForm'];

        form.elements['imageUrl'].value = bicycle.imageUrl;
        form.elements['popularity'].value = bicycle.popularity;
        form.elements['model'].value = bicycle.model;
        form.elements['price'].value = bicycle.price;
        form.elements['company'].value = bicycle.company;
        form.elements['year'].value = bicycle.year;
        form.elements['country'].value = bicycle.country;

        let img = document.getElementById("img");
        img.src = bicycle.imageUrl;

        let saveButton = document.getElementById('save');
        saveButton.addEventListener('click', function (e) {

            e.preventDefault()

            const form = document.forms['editForm']
            const imageUrl = form.elements['imageUrl'].value
            const popularity = form.elements['popularity'].value
            const model = form.elements['model'].value
            const price = form.elements['price'].value
            const company = form.elements['company'].value
            const year = form.elements['year'].value
            const country = form.elements['country'].value
            const id = bicycle.bicycleId

            editBicycle({ id, popularity, imageUrl, model, price, company, year, country });
        })

    }
    else {

        let saveButton = document.getElementById('save');

        saveButton.addEventListener('click', function (e) {

            e.preventDefault()

            const form = document.forms['editForm']
            const imageUrl = form.elements['imageUrl'].value
            const popularity = form.elements['popularity'].value
            const model = form.elements['model'].value
            const price = form.elements['price'].value
            const company = form.elements['company'].value
            const year = form.elements['year'].value
            const country = form.elements['country'].value

            createBicycle({popularity, imageUrl, model, price, company, year, country });
        })

    }


}


function createHtmlBicycle(bicycle) {
    let divContainer = document.createElement("div");
    divContainer.classList.add("d-flex")
    divContainer.classList.add("border")
    divContainer.classList.add("border-danger")
    divContainer.classList.add("rounded")
    divContainer.classList.add("mb-2")
    divContainer.classList.add("p-3")
    divContainer.classList.add("align-items-center")
    divContainer.classList.add("bg-white")
    divContainer.classList.add("bicycle-container")
    divContainer.setAttribute("id", bicycle.bicycleId)

    let divImgContainer = document.createElement("div");
    divImgContainer.classList.add("w-50")
    divImgContainer.classList.add("bicycle-small")

    let img = document.createElement("img");
    img.src = bicycle.imageUrl;
    img.classList.add("w-100");
    img.classList.add("p-4");
   

    divImgContainer.append(img);
    divContainer.append(divImgContainer);

    let elementDivContainer = document.createElement("div");
    elementDivContainer.classList.add("w-50")
    elementDivContainer.classList.add("d-flex")
    elementDivContainer.classList.add("flex-column")
    elementDivContainer.classList.add("align-items-center")
    elementDivContainer.classList.add("bicycle-small")

    divContainer.append(elementDivContainer);

    let infoDiv = document.createElement("div");
    infoDiv.classList.add("bg-dark")
    infoDiv.classList.add("text-light")
    infoDiv.classList.add("w-100")
    infoDiv.classList.add("text-center")
    infoDiv.classList.add("rounded")
    infoDiv.classList.add("border")
    infoDiv.classList.add("mb-2")

    infoDiv.innerText = "Info";

    elementDivContainer.append(infoDiv);

    let arr = ["popularity", "model", "price", "company", "year", "country"];

    arr.forEach(element => {

        let divPropertyContainer = document.createElement("div");
        divPropertyContainer.classList.add("d-flex")
        divPropertyContainer.classList.add("justify-content-between")
        divPropertyContainer.classList.add("w-75")

        let divHeader = document.createElement("div");
        divHeader.innerText = element;

        let divValue = document.createElement("div");
        if (element != "popularity") {
            divValue.innerText = bicycle[element];
        }
        else {
            divValue.innerText = +bicycle[element]+1;
        }
        divValue.setAttribute("id", element);

        divPropertyContainer.append(divHeader);
        divPropertyContainer.append(divValue);

        elementDivContainer.append(divPropertyContainer);
    })

    let buttonDelete = document.createElement("button");
    buttonDelete.innerText = "Delete";
    buttonDelete.classList.add("btn");
    buttonDelete.classList.add("btn-secondary");
    buttonDelete.classList.add("w-100");
    buttonDelete.classList.add("my-2");
    buttonDelete.setAttribute("value", bicycle.bicycleId)
    buttonDelete.addEventListener("click", function () {

        deleteBicycle(bicycle.bicycleId);

    })

    let buttonEdit = document.createElement("button");
    buttonEdit.innerText = "Edit";
    buttonEdit.classList.add("btn");
    buttonEdit.classList.add("btn-secondary");
    buttonEdit.classList.add("w-100");
    buttonEdit.setAttribute("value", bicycle.bicycleId)
    buttonEdit.addEventListener("click", function () {

        sessionStorage.setItem('bicycle', JSON.stringify(bicycle));
        location.pathname = '/edit-page.html'

    })

    elementDivContainer.append(buttonDelete);
    elementDivContainer.append(buttonEdit);

    return divContainer;
} 

async function deleteBicycle(bicycleId) {

    let response = await fetch('api/bicycles/' + `${bicycleId}`, {

        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json'
        }
    })

    if (response.ok === true) {

        let elem = document.getElementById(bicycleId);
        elem.parentNode.removeChild(elem);

    }
}

async function editBicycle({ id, popularity, imageUrl, model, price, company, year, country }) {

    const response = await fetch('/api/bicycles', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({

            bicycleId: +id,
            popularity: +popularity,
            imageUrl,
            model,
            price: +price,
            company,
            year: +year,
            country
        })
    })

    if (response.ok === true) {

        window.location = "index.html";
        document.getElementById('errors').classList.add('d-none')
        
    }
    else {
        const errorData = await response.json()

        document.getElementById('errors').classList.remove('d-none')
        let errorsDiv = document.getElementById('errors');

        while (errorsDiv.firstChild) {
            errorsDiv.removeChild(errorsDiv.lastChild)
        }

        if (errorData) {

            if (errorData.errors) {

                if (errorData.errors["ImageUrl"]) {

                    showError(errorData.errors["ImageUrl"])
                }

                if (errorData.errors["Model"]) {
                    showError(errorData.errors["Model"])
                }

                if (errorData.errors["Price"]) {
                    showError(errorData.errors["Price"])
                }

                if (errorData.errors["Company"]) {
                    showError(errorData.errors["Company"])
                }


                if (errorData.errors["Year"]) {
                    showError(errorData.errors["Year"])
                }

                if (errorData.errors["Country"]) {
                    showError(errorData.errors["Country"])
                }
            }

            if (errorData["Price"]) {
                showError(errorData["Price"])
            }

            if (errorData["Year"]) {
                showError(errorData["Year"])
            }

        }
    }
 }


function showError(errors) {

    let errorsDiv = document.getElementById('errors');

    errors.forEach(error => {
        const div = document.createElement("div");
        div.innerText = error;
        errorsDiv.append(div)
    })
}

async function createBicycle({popularity, imageUrl, model, price, company, year, country }) {

    const response = await fetch('/api/bicycles', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            imageUrl,
            popularity: +popularity,
            model,
            price: +price,
            company,
            year: +year,
            country
        })
    })

    if (response.ok === true) {

        window.location = "index.html";
        document.getElementById('errors').classList.add('d-none')
    }
    else
    {
        const errorData = await response.json()
        document.getElementById('errors').classList.remove('d-none')
        let errorsDiv = document.getElementById('errors');


        while (errorsDiv.firstChild) {
            errorsDiv.removeChild(errorsDiv.lastChild)
        }

        if (errorData) {

            if (errorData.errors) {

                if (errorData.errors["ImageUrl"]) {

                    showError(errorData.errors["ImageUrl"])
                }

                if (errorData.errors["Model"]) {
                    showError(errorData.errors["Model"])
                }

                if (errorData.errors["Price"]) {
                    showError(errorData.errors["Price"])
                }

                if (errorData.errors["Company"]) {
                    showError(errorData.errors["Company"])
                }


                if (errorData.errors["Year"]) {
                    showError(errorData.errors["Year"])
                }

                if (errorData.errors["Country"]) {
                    showError(errorData.errors["Country"])
                }
            }

            if (errorData["Price"]) {
                showError(errorData["Price"])
            }

            if (errorData["Year"]) {
                showError(errorData["Year"])
            }

        }


    }

}

async function getBicycles() {
    const response = await fetch('api/bicycles');
    if (response.ok === true) {
        const bicycles = await response.json();

        bicycles.forEach(bicycle => {
            document.getElementById("bicycleItemsList").append(createHtmlBicycle(bicycle));
        })

    }
}