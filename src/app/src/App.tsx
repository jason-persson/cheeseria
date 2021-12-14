import React, { useEffect, useState } from 'react';
import { Cheese } from './Cheese';

export const API_BASE = process.env.NODE_ENV === 'development'
  ? 'http://localhost:5002/'
  : 'http://localhost/';

function App() {

  const [cheeses, setCheeses] = useState<Cheese[]>([]);

  useEffect(() => {
    fetch(API_BASE + 'cheeses')
      .then(response => response.json())
      .then(data => {
        setCheeses(data);
      })
      .catch(err => console.log(err));
  });

  return (
    <div className="App">
      <h1>Cheese list:</h1>
      <ul>
        {
          cheeses.map(x => <li key={x.id}>{x.name}</li>)
        }
      </ul>
    </div>
  );
}

export default App;
