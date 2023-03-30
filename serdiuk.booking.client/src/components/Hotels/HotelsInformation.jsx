import React from 'react'

export default function HotelsInformation() {
  return (
    <div className='col-sm-2 bg-light row'>
        <div className='col-md-8 offset-md-2'>

            <button onClick={()=>{
                window.location.href = '/orders'
            }} className='mt-3 btn btn-primary btn-lg '>Заказы</button>
        </div>
    </div>
  )
}
