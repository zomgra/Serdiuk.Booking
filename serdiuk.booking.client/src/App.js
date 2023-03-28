import './App.css';
import { useEffect, useState } from 'react';
import { bookingNumberHandler, getHotelsByFilter } from './services/hotelsService';
import { Route, Routes } from 'react-router-dom';
import HotelPage from './components/Hotel/HotelPage';
import PrivateRoute from './utils/Routers/PrivateRoute'
import { userManager } from './utils/userManager'
import Login from './components/Login/Login';
import Home from './components/Front/Home';
import SignInCallback from './components/Callbacks/SignInCallback'
import OrderList from './components/Order/OrderList';
import OrderView from './components/Order/OrderView';

function App() {

  const [hotels, setHotels] = useState([]);
  const [user, setUser] = useState()


  useEffect(() => {
    async function getHotels() {
      await loadHotelsByFilter(null);
    }
    async function getUser() {
      setUser(await userManager.getUser())
      console.log(user);
    }
    getUser();
    getHotels()
  }, [])

  async function loadHotelsByFilter(data) {
    if (data) {
      var currentData = {
        minCost: data.selectedPrice[0],
        maxCost: data.selectedPrice[1],
        numberType: data.selectedType.Id
      }
    }
    else {
      var currentData = {
      }
    }

    let selectedHotels = await getHotelsByFilter(currentData);
    console.log(selectedHotels);
    await setHotels(selectedHotels);
  }
  async function bookingNumber(data) {

    console.log(data);
    var result = await bookingNumberHandler(data);
    console.log(result);
  }


  return (
    <div className='row d-flex'>
      <Routes>
        <Route element={<PrivateRoute />}>
          <Route element={<Home  user={user} loadHotelsByFilter={loadHotelsByFilter} hotels={hotels}/>} path="/"></Route>
          <Route path='/hotel/:id' element={<HotelPage bookingNumber={bookingNumber}/>}></Route>
          <Route path='/orders' element={<OrderList/>}></Route>
        </Route>
        <Route element={<Login/>}  path="/login">
        </Route>
        <Route path='/signin-oidc' element={<SignInCallback/>}></Route>

      </Routes>
    </div>
  );
}

export default App;
