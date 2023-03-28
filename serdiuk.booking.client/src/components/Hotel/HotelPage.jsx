import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom'
import { getNumberByHotelId } from '../../services/hotelsService';
import NumberView from '../Number/NumberView';

export default function HotelPage({bookingNumber}) {

  const [numbers, setNumbers] = useState();
  const { id } = useParams();

  useEffect(() => {
    async function getNumbers() {
      let numbers = await getNumberByHotelId(id);
      console.log(numbers);
      setNumbers(numbers);
    }
    getNumbers();
  }, []);


  if (numbers)
    return (
      <div className='row'>
        { numbers.map((number, id) => <NumberView key={id} image={number.image} id={number.numberId} bookingNumber={bookingNumber} numType={number.type} numberCost={number.numberCost} available={number.isAvailable} />) }
      </div>
    )
  else
    return
  <div>
    Loading..
  </div>
}
