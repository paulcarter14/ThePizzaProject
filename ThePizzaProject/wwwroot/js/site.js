function redirectToRandomPizzaPage() {

    //hämtar antalet pizzor med hjälp av api
    fetch('/api/pizza-count')
        .then(response => response.json())
        .then(count => {
            //slumpar fram en pizza
            const randomPizzaId = Math.floor(Math.random() * count) + 1;
            //skickar oss till hemsidan
            window.location.href = `/ThePizzaPage?id=${randomPizzaId}`;
        })
        .catch(error => console.error('Error:', error));
}