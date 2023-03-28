import {useState} from 'react'

export default function NumberDatePicker({id, bookingNumber}) {

    const [dateStart, setDateStart] = useState();
    const [dateEnd, setDateEnd] = useState();

    return (
        <div>
            <p className='text-success'>Available</p>
            <input type="date" name='dateStart' onChange={(e)=>setDateStart(e.target.value)}/>
            <input type="date" name='dateEnd'  onChange={(e)=>setDateEnd(e.target.value)}/>
            <button onClick={() => bookingNumber({
                numberId: id,
                dateStart: dateStart,
                dateEnd: dateEnd,
            })}>Order</button>
        </div>
    )
}
