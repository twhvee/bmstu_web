import React, {createContext, useContext} from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import UserStore from "./store/UserStore";
import {BookStore} from "./store/BookStore";
import {Provider} from "react-redux";
import { setupStore } from './store/store';



type RootStateContextValue ={
  userstore : UserStore;
}

export const RootStateContext = React.createContext<RootStateContextValue>({} as RootStateContextValue)

const userstore = new UserStore()

export const RootStateProvider : React.FC<React.PropsWithChildren<{}>> = ({children, }) => {
  return (<RootStateContext.Provider value={{userstore}}>
    {children}
  </RootStateContext.Provider>)
}


export const useRootStore = () => React.useContext(RootStateContext)

/*
interface ContextValue {
  user: any; 
  book: any;
}

export const Context = React.createContext<ContextValue>({
  user: null,
  book: null,
  
});
*/

const store = setupStore()

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <React.StrictMode>
    <Provider store={store}>
    <RootStateProvider>
        <App />
    </RootStateProvider>
    </Provider>

    
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
