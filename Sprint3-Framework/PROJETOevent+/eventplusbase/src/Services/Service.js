import axios from "axios";

const apiPort = "7118";
// const localApi = `https://localhost:${apiPort}/api`;
const externallApiUrl =`https://eventcatarina.azurewebsites.net/api`;

const api = axios.create({
    baseURL : externallApiUrl
});


export default api;