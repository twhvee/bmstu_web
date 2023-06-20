import React from 'react'
import {
    Routes,
    Link, 
    Route, 
    Navigate,
    BrowserRouter as Router
  } from "react-router-dom";

import { publicRoutes } from '../Pages/routes';

export default function AppRouter() {
  const isAuth : boolean = false
  return (
    <div>
        <Routes>
        {publicRoutes.map(({path, Component}) =>
            <Route key = {path} path={path} element={<Component/>}/>
        )}
          <Route path="*" element={<Navigate to="/home" replace />} />
        </Routes>
      
    </div>
  )
}
