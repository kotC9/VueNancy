import axios from 'axios';

var HTTP = axios.create({
    baseURL: 'http://127.0.0.1:8081/api'
})


export function post(url, data, config) {
    return HTTP.post(url, data, config);
}
export function get(url, config) {
    return HTTP.get(url, config);
}