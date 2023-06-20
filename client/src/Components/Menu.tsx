import React from 'react'
import { Dispatch, SetStateAction, FunctionComponent } from 'react';


interface menuLink {
    value: string;
    href: string;
  }
  
 
  
export default function Menu ( props : {items : menuLink[],  active : boolean|null, setActive: Dispatch<SetStateAction<boolean | null>>} ) {
  return (
    <div className={props.active ?'menu active': 'menu'} onClick={()=>props.setActive(false)}>      
            <ul onClick={e=> e.stopPropagation()}>
                {props.items.map(item=>
                    <li>
                        <a href={item.href}>{item.value}</a>
                                              
                    </li>)}
            </ul>     
    </div>
  )
}
