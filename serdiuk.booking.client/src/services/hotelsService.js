import axios from 'axios';
import { DEFAULT_API_URL } from '../utils/constance';

const instance = axios.create({
    baseURL: DEFAULT_API_URL,
});

export async function getHotelsByFilter(data) {
    var responce = await instance.get("/hotel", {
        params: data,
        method:"GET"
    })
    return (responce.data);
}
export async function getNumberByHotelId(id) {
    console.log(id);
    var responce = await instance.get("/hotel/numbers", {
        params: {HotelId:id},
        method: "GET"
    })
    return responce.data;
}