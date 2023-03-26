import './App.css';
import 'bootstrap/dist/css/bootstrap.css';
import FilterBar from './components/FilterBar/FilterBar';
import { useEffect, useState } from 'react';
import { getHotelsByFilter } from './services/hotelsService';

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
        minCost: 0,
        maxCost : 0,
      }
    }
    
    let selectedHotels = await getHotelsByFilter(currentData);
    console.log(selectedHotels);
    await setHotels(selectedHotels);
  }


  return (
   <div>
    <FilterBar loadData={loadHotelsByFilter}/>
   </div>
  );
}

export default App;
