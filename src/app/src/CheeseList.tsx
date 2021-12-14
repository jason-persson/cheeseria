import React from 'react';
import { Cheese } from './Cheese';
import './bulma.css';
import CheeseCard from './CheeseCard';

type Props = {
    cheeses: Cheese[]
}

function CheeseList({ cheeses }: Props) {
    return (
        <div className='container'>
            <div className='columns is-centered'>
                <div className='column is-half'>
                    {
                        cheeses.map(x => <CheeseCard key={x.id} cheese={x} />)
                    }
                </div>
            </div>
        </div>
    )
}

export default CheeseList;