import React from 'react';
import styles from './ImageInput.module.css';


export const ImageInput = ({name, value, onChange, accept, multiple, previews, disabled}) => {
    return (
        <>
            {multiple

                ?
                <label className={styles.uploadBtnWrapper}>
                    <input
                        type="file"
                        name={name}
                        value={value}
                        onChange={onChange}
                        accept={accept}
                        multiple={multiple}
                        disabled={disabled}
                    />
                    <img className={styles.checkmark} src={previews}/>
                </label>
                :
                <label htmlFor="photo-upload" className={styles.fileUpload}>
                    <div className={styles.imgWrap}>
                        <img htmlFor="photo-upload" src={previews}/>
                    </div>
                    <input
                        id="photo-upload"
                        type="file"
                        name={name}
                        value={value}
                        onChange={onChange}
                        accept={accept}
                        disabled={disabled}

                    />
                </label>

            }

        </>

    );
}
