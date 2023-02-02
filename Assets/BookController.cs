using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookController : MonoBehaviour
{
    public GameObject[] defenders;

    public GameObject book;

    public GameObject normalBookButton, firstTimeBookButton;

    void Start()
    {
        updateBookButtonVisibility();
    }

    void updateBookButtonVisibility()
    {
        if (PlayerPrefs.GetInt("bookShowed", 0) == 0)
        {
            normalBookButton.SetActive(false);
            firstTimeBookButton.SetActive(true);
        }
        else
        {
            normalBookButton.SetActive(true);
            firstTimeBookButton.SetActive(false);
        }
    }

    public void setBookVisibility(bool visibility)
    {
        book.SetActive(visibility);

        PlayerPrefs.SetInt("bookShowed", 1);

        updateBookButtonVisibility();
    }

}
