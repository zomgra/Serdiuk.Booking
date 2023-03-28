import React from 'react'
import FilterBar from '../FilterBar/FilterBar'
import HotelList from '../Hotel/HotelList'
export default function Home({loadHotelsByFilter, hotels, user}) {
  return (
    <div>
        <FilterBar loadData={loadHotelsByFilter}/>
        <HotelList hotels={hotels}/>
    </div>
  )
}
