import React from 'react'
import { NUMBER_TYPES } from '../FilterBar/filterData'
import NumberDatePicker from './NumberDatePicker'

export default function NumberView({ image, numType, numberCost, available, id, bookingNumber }) {


  return (
    <div className='py-3 pt-3 col-4 border-bottom'>
      <div className='pb-2'>
        <img alt='' src={image} className='rounded img-thumbnail' />
      </div>
      <p>Type: {(NUMBER_TYPES.find(item => item.Id === numType)?.Name)}</p>
      <p>Cost: {numberCost}</p>
      {available ?
        (<>
          <NumberDatePicker id={id} bookingNumber={bookingNumber}/>
        </>
        ) :
        (<p className='text-danger'>Not Available</p>)
      }

    </div>
  )
}
