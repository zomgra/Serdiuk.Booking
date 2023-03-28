import React from 'react'
import { NUMBER_TYPES } from '../FilterBar/filterData'

export default function NumberView({ image, numType, numberCost, available }) {


  return (
    <div className='py-3 pt-3 border-bottom'>
      <div className='pb-2'>
        <img alt='' src={image} className='rounded img-thumbnail' />
      </div>
      <p>Type: {(NUMBER_TYPES.find(item => item.Id === numType)?.Name)}</p>
      <p>Cost: {numberCost}</p>
      {available ?
        (<>
          <p className='text-success'>Available</p>
          <button>Order</button>
        </>
        ) :

        (<p className='text-danger'>Not Available</p>)
      }

    </div>
  )
}
