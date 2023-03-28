import React from 'react'
import HotelView from './HotelView'

export default function HotelList({hotels}) {
  return (
    <div className='p-4 pt-2 col-3 justify-content-center'>
        {hotels.map(hotel => <HotelView key={hotel.id} hotel={hotel}/>)}
    </div>
  )
}
