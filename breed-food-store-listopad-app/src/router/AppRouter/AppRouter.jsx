import React from 'react'
import { Route, Routes } from 'react-router-dom'
import { routes } from './../routes';

const AppRouter = () => {
  return (<div>
    <div>
      <Routes path="/">
        {routes.map((rout) => (
          <Route
            exact={rout.exact}
            path={rout.path}
            element={rout.element}
            key={rout.path}
          ></Route>
        ))}
      </Routes>
    </div>
  </div>
  )
}

export default AppRouter