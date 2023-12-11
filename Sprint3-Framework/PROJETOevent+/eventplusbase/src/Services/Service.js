import axios from "axios";

// const apiPort = "7118";
// const localApi = `https://localhost:${apiPort}/api`;
const externallApiUri =`https://eventcatarina.azurewebsites.net/api`;

const api = axios.create({
    baseURL : externallApiUri
});


export default api;