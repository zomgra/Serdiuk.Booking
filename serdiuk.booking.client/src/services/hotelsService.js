import axios from 'axios';
import { DEFAULT_API_URL } from '../utils/constance';
import { userManager } from '../utils/userManager';

async function getToken(){
    const user = await userManager.getUser();
const token =`Bearer ${user.access_token}`
return token;
}

const instance = axios.create({
    baseURL: DEFAULT_API_URL,
});

export async function getHotelsByFilter(data) {
    var responce = await instance.get("/hotel", {
        params: data,
        method: "GET"
    })
    return (responce.data);
}
export async function getNumberByHotelId(id) {
    var responce = await instance.get("/hotel/numbers", {
        params: { HotelId: id },
       
    })
    return responce.data;
}
export async function bookingNumberHandler(data) {
    
    console.log(await getToken());
    var responce = await instance.post('/hotel/numbers', JSON.stringify(data), {
        
        headers: {
            'Authorization': await getToken(),
            'Content-Type': 'application/json',
        },
    })
    console.log(responce);
    return responce.data;
}
export async function getUserOrders() {
    console.log(await getToken());
    var responce = await instance.get('/hotel/orders', {
            headers:{
                'Authorization': await getToken(),
            }
    })
    console.log(responce);
    return responce.data;
}