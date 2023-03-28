import { Grid } from '@mui/material';
import React, { useEffect, useState } from 'react'
import { NUMBER_TYPES, PRICE_FILTER } from './filterData';
export default function FilterBar({ loadData }) {

    const [prices, setPrices] = useState([]);
    const [types, setType] = useState([]);

    const [selectedType, setSelectedType] = useState();
    const [selectedPrice, setSelectedPrice] = useState();

    useEffect(() => {
        setPrices(PRICE_FILTER);
        setType(NUMBER_TYPES)
    }, [])


    function supplyFilter(e) {
        e.preventDefault();
        let data = { selectedPrice, selectedType };
        loadData(data);
    }

    function renderPrice(price, key) {
        return (
            <li key={key}>
                <div className='py-1'>
                    <label className='form-check-label'>
                        {price[0]} - {price[1]}
                        <input name='cost' className='form-check-input' onClick={() => setSelectedPrice(price)} value={price} type='radio' />
                    </label>

                </div>
            </li>)
    }
    function renderType(type, key) {
        return (
            <div key={key}>
                <div className='py-1'>
                    <label className='form-check-label'>
                        {type.Name}
                        <input name='type' className='form-check-input' onClick={() => setSelectedType(type)} value={type} type='radio' />
                    </label>
                </div>
            </div>)
    }

    return (
            <div className='col-sm-2'>
                <div className='p-2 bg-light border' id='filter'>
                    <div className="border-bottom h5 text-center text-uppercase">Filter By</div>
                    <form id='filterForm' >
                        <div className='box border-bottom '>
                            PRICES
                            <fieldset>
                                <ul className='inner-box collapse show form-check'>
                                    {prices.map((price, id) => renderPrice(price, id))}
                                </ul>
                            </fieldset>
                        </div>
                        <div className='box border-bottom'>
                            TYPES
                            <fieldset>
                                <div className='inner-box collapse show form-check'>
                                    {types.map((type, id) => renderType(type, id))}
                                </div>
                            </fieldset>
                        </div>
                        <button className='btn btn-info my-1 mx-3' onClick={(e) => { supplyFilter(e) }}>Filter</button>
                    </form>
                </div>
            </div>
    )
}
