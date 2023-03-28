import './App.css';
import FilterBar from './components/FilterBar/FilterBar';
import { useEffect, useState } from 'react';
import { getHotelsByFilter } from './services/hotelsService';
import HotelList from './components/Hotel/HotelList';
import { Route, Routes } from 'react-router-dom';
import HotelPage from './components/Hotel/HotelPage';


function App() {

  const [hotels, setHotels] = useState([]);

  useEffect(()=>{
    async function getHotels(){
      await loadHotelsByFilter(null);
    }
    getHotels()
  }, [])

  async function loadHotelsByFilter(data) {
    if(data){
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


  return (
   <div className='row d-flex'>
    <Routes>
      <Route path='/' element=
      {
        <>
        <FilterBar loadData={loadHotelsByFilter}/>
        <HotelList hotels={hotels}/>
        </>
      }></Route>
      <Route path='/hotel/:id' element={<HotelPage/>}></Route>
    </Routes>
   </div>
  );
}

export default App;
