import React, { useRef } from "react";
import classes from "./Input.module.css";

const Input = ({
  value,
  setValue,
  width,
  className,
  style,
  maxLength = null,
}) => {
  const bodyRef = useRef();
  const inputRef = useRef();

  return (
    <div className={className} style={style}>
      <div
        style={{ width: width }}
        ref={bodyRef}
        className={classes.body}
        onMouseDown={() => {
          setTimeout(() => {
            inputRef.current.focus();
          }, 0);
        }}
      >
        <input
          ref={inputRef}
          className={classes.input}
          value={value}
          onFocus={() => {
            bodyRef.current.classList.add(classes.input__active);
          }}
          onBlur={() => {
            bodyRef.current.classList.remove(classes.input__active);
          }}
          onChange={(e) => {
            if (maxLength === null || maxLength >= e.target.value.length) {
              setValue(e.target.value);
            }
          }}
        />
      </div>
    </div>
  );
};

export default Input;
