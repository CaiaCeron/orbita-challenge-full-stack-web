import axios from 'axios';

const api = axios.create({

    baseURL: 'https://localhost:44345'
})

export default api;