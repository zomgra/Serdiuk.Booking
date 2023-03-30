import React from 'react'
import FilterBar from '../FilterBar/FilterBar'
import HotelList from '../Hotel/HotelList'
import HotelsInformation from '../Hotels/HotelsInformation'
export default function Home({loadHotelsByFilter, hotels, user}) {
  return (
    <div className='row'>
        <FilterBar loadData={loadHotelsByFilter}/>
        <HotelList hotels={hotels}/>
        <HotelsInformation/>  
    </div>
  )
}
