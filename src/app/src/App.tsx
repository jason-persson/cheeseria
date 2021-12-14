import React, { useEffect, useState } from 'react';
import { Cheese } from './Cheese';
import CheeseList from './CheeseList';
import { fetchCheeses } from './api';
import './bulma.css';

function App() {

  const [cheeses, setCheeses] = useState<Cheese[]>([]);

  useEffect(() => {
    fetchCheeses().then(cheeses => setCheeses(cheeses));
  });

  return (
    <>
      {<section className='hero is-info'>
        <div className='hero-body'>
          <p className='title'>Patient Zero Cheeseria</p>
          <p className='subtitle'>We sell the best cheeses</p>
        </div>
      </section>}
      <section>
        <CheeseList cheeses={cheeses} />
      </section>
    </>
  );
}

export default App;
