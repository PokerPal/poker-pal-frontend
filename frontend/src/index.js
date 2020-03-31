import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import {CookiesProvider, Provider} from 'react-cookie';
import './index.css';
// import BrowserRouter from "react-router-dom/modules/BrowserRouter";

/*let initialStore = {

};
const store = createStore(rootReducer, initialStore);*/

ReactDOM.render(
  <CookiesProvider>
    <App />
  </CookiesProvider>,
  document.getElementById('root')
);
